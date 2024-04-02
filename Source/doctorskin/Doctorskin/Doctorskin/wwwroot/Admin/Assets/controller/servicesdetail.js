var servicesDetail = {
    init: function () {
        servicesDetail.tblServices();
        servicesDetail.tblServiceDetail();
        $('#btnSeach').click(function () {
            servicesDetail.tblServices();
            servicesDetail.tblServiceDetail();
        });
        $('#btnCreate').click(function () {
            $('#titleModal').text('Thêm mới dịch vụ');
            $('#ipHiddenId').val(0);
            $('#ipNameDV').val('');
            $('#txtDescDV').val('');
            $('#ipFileUpload').val('');
            $('#modalsAddEditServices').modal('show');
        });
        $('#btnCreateDetail').click(function () {
            $('#titleModalDetail').text("Thêm mới chi tiết dịch vụ");
            $('#ipIdDetail').val(0);
            $('#ipAmountDetail').val(0);
            $('#ipPriceDetail').val(0);
            $('#txtDescDetail').val('');
            $('#ipNameDetail').val('');
            $('#ipFileUpload').val('');
            $('#modalsAddEditSvDetail').modal('show');
        });
        $('#btnSubmit').click(function () {
            var formData = new FormData();
            formData.append("Id", $('#ipHiddenId').val());
            formData.append("NameDt", $('#ipNameDV').val());
            formData.append("DescDt", $('#txtDescDV').val());
            var fileUpload = $("#ipFileUpload").get(0);
            var files = fileUpload.files;
            formData.append("fileUpload", files[0]);
            $.ajax({
                url: '/Admin/ServicesDetail/CreateOrEdit',
                type: 'post',
                contentType: false,
                processData: false,
                data: formData,
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblService").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEditServices').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
        $('#btnSubmitDetail').click(function () {
            var formData = new FormData();
            formData.append("Id", $('#ipIdDetail').val());
            formData.append("NameSd", $('#ipNameDetail').val());
            formData.append("DescDe", $('#txtDescDetail').val());
            formData.append("Amount", $('#ipAmountDetail').val());
            formData.append("PriceSd", $('#ipPriceDetail').val());
            formData.append("IdDt", $('#ipIdService').val());
            var fileUpload = $("#ipFileUpload").get(0);
            var files = fileUpload.files;
            formData.append("fileUpload", files[0]);
            $.ajax({
                url: '/Admin/ServicesDetail/CreateOrEditDetail',
                type: 'post',
                contentType: false,
                processData: false,
                data: formData,
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblServiceDetail").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEditSvDetail').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblServices: function () {
        $("#tblService").bootstrapTable('destroy');
        $("#tblService").bootstrapTable({
            method: 'get',
            url: "/Admin/ServicesDetail/GetServiceData",
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
                    field: "nameDt",
                    title: "Tên dịch vụ",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '<a href="/Admin/ServicesDetail/ServiceDetail?Id=' + row.id + '">' + value + '</a>';
                        return html;
                    }
                },

                {
                    field: "hideDt",
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
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái dịch vụ này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/ServicesDetail/ChangeIsActive',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblService").bootstrapTable('refresh', { silent: true });
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
                        action += '<a class=" btn btn-primary btn-sm btnEdit" title="Sửa"><i class="bx bx-pencil"></i></a>';
                        return action;
                    },
                    events: {
                        'click .btnEdit': function (e, value, row, index) {
                            $('#titleModal').text('Chỉnh sửa dịch vụ');
                            $('#ipHiddenId').val(row.id);
                            $('#ipNameDV').val(row.nameDt);
                            $('#txtDescDV').val(row.descDt);
                            $('#ipFileUpload').val('');
                            if (row.imgDt != undefined && row.imgDt != null && row.imgDt != '') {
                                var html = '<img src="/Uploads/Service/' + row.imgDt + '" alt="avatar" class="mt-1" width="80" height="60" />';
                                $('#lbImage').html(html);
                            }
                            $('#modalsAddEditServices').modal('show');
                        },
                    }
                },

            ],
            onLoadSuccess: function (data) {

            },
        })
    },
    tblServiceDetail: function () {
        $("#tblServiceDetail").bootstrapTable('destroy');
        $("#tblServiceDetail").bootstrapTable({
            method: 'get',
            url: "/Admin/ServicesDetail/GetServiceDetailData",
            queryParams: function (p) {
                var param = $.extend(true, {
                    serviceId: $('#ipIdService').val(),
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
                    field: "nameSd",
                    title: "Tên dịch vụ",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "amount",
                    title: "Số lượng",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "priceSd",
                    title: "Giá tiền",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        return accounting.formatMoney(value, "", 0, ",", ".", "%v%s");
                    }
                },
                {
                    field: "hideSd",
                    title: "Trạng thái",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<button class="btn btn-danger btn-sm btnHide">Ẩn</button>';
                        } else {
                            html += '<button class="btn btn-success btn-sm btnHide">Hiển thị</button>';
                        }
                        return html;
                    },
                    events: {
                        'click .btnHide': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái dịch vụ này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/ServicesDetail/ChangeIsHidenSd',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblServiceDetail").bootstrapTable('refresh', { silent: true });
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
                        action += '<a class=" btn btn-primary btn-sm btnEdit" title="Sửa"><i class="bx bx-pencil"></i></a>';
                        return action;
                    },
                    events: {
                        'click .btnEdit': function (e, value, row, index) {
                            $('#titleModalDetail').text("Chỉnh sửa chi tiết dịch vụ");
                            $('#ipIdDetail').val(row.id);
                            $('#ipAmountDetail').val(row.amount);
                            $('#ipPriceDetail').val(row.priceSd);
                            $('#txtDescDetail').val(row.descDe);
                            $('#ipNameDetail').val(row.nameSd);
                            $('#ipFileUpload').val('');
                            if (row.imgSd != undefined && row.imgSd != null && row.imgSd != '') {
                                var html = '<img src="/Uploads/Service/' + row.imgSd + '" alt="avatar" class="mt-1" width="80" height="60" />';
                                $('#lbImageDetail').html(html);
                            }
                            $('#modalsAddEditSvDetail').modal('show');
                        },
                    }
                },

            ],
            onLoadSuccess: function (data) {

            },
        })
    },
}
$(document).ready(function () {
    servicesDetail.init();
});