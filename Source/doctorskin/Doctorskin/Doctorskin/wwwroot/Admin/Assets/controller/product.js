var product = {
    init: function () {
        product.tblProduct();
        $('#btnSeach').click(function () {
            product.tblProduct();
        });
        $('#btnCreateSubmit').on('click', function () {
            var formData = new FormData();
            formData.append("Id", $('#ipIdHidden').val());
            formData.append("Namep", $('#ipNamep').val());
            formData.append("CateId", $('#sltCateId').val());
            formData.append("Newprice", $('#ipNewPrice').val());
            formData.append("Oldprice", $('#ipOldPrice').val());
            formData.append("Statep", $('#sltStatep').val());
            formData.append("Avilability", $('#sltAvilability').val());
            var fileUpload = $("#ipFileUpload").get(0);
            var files = fileUpload.files;
            formData.append("fileUpload", files[0]);
            formData.append("Idbrand", $('#sltBranchId').val());
            formData.append("Hide", $('#ckHidden').val());
            var desc = CKEDITOR.instances['TxtDescription'].getData();
            formData.append('Descr', desc);
            $.ajax({
                url: '/Admin/Product/CreateOrEdit',
                type: 'post',
                processData: false,
                contentType: false,
                data: formData,
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        setTimeout(function () {
                            window.location.href = '/Admin/Product';
                        },1500);
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblProduct: function () {
        $("#tblProducts").bootstrapTable('destroy');
        $("#tblProducts").bootstrapTable({
            method: 'get',
            url: "/Admin/Product/GetProductData",
            queryParams: function (p) {
                var param = $.extend(true, {
                    search: $('#txtSearch').val(),
                    offset: p.offset,
                    limit: p.limit,
                }, p);
                return param;
            },
            formatLoadingMessage: function () {
                return '<span>Đang tải dữ liệu...</span>';
            },
            formatNoMatches: function () {
                return '<span>Không có dữ liệu</span>';
            },
            striped: true,
            sidePagination: 'server',
            pagination: true,
            paginationVAlign: 'bottom',
            search: false,
            pageSize: 10,
            pageList: [10, 50, 500],
            columns: [

                {
                    field: "namep",
                    title: "Tên sản phẩm",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "namec",
                    title: "Loại",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "namebrand",
                    title: "Hiệu",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "img",
                    title: "Ảnh",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value != null && value != undefined && value != '') {
                            html += '<img style="width:50px;height=50px;object-fit:cover" src="/Uploads/Product/' + value + '" />'
                        }
                        return html;
                    }
                },
                {
                    field: "newprice",
                    title: "Giá",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        return accounting.formatMoney(value, "", 0, ",", ".", "%v%s");
                    }
                },
                {
                    field: "avilability",
                    title: "Tình trạng",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "statep",
                    title: "Nhóm",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "hide",
                    title: "Trạng thái",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<button class="btn btn-danger btn-sm btnIsActive">Ẩn</button>';
                        } else {
                            html += '<button class="btn btn-success btn-sm btnIsActive">Hiển thị</button>';
                        }
                        return html;
                    },
                    events: {
                        'click .btnIsActive': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái sản phẩm này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Product/ChangeIsHide',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblProducts").bootstrapTable('refresh', { silent: true });
                                                    }
                                                    else {
                                                        base.error(res.message);
                                                    }
                                                }
                                            });
                                        }
                                    },
                                    cancel: {
                                        text: 'Đóng',
                                        btnClass: 'btn btn-danger'
                                    },
                                }
                            });
                        }
                    }
                },
                {
                    title: "Chức năng",
                    valign: 'middle',
                    align: 'center',
                    class: 'CssAction',
                    formatter: function (value, row, index) {
                        var action = "";
                        action += '<a href="/Admin/Product/CreateOrEdit?Id=' + row.id + '" class="btn btn-primary btn-sm btnEdit" title="Sửa"><i class="bx bx-pencil"></i></a>';
                        return action;
                    },
                },

            ],
            onLoadSuccess: function (data) {

            },
        })
    },
}
$(document).ready(function () {
    product.init();
});