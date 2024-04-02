﻿var categories = {
    init: function () {
        categories.tblCategory();
        $('#btnSeach').click(function () {
            categories.tblCategory();
        });
        $('#btnCreate').click(function () {
            $('#ipHiddenId').val(0);
            $('#ipNamec').val('');
            $('#titleModal').text('Thêm loại sản phẩm');
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            $.ajax({
                url: '/Admin/Categories/CreateOrEdit',
                type: 'post',
                dataType: 'json',
                data: $('#frmCategory').serialize(),
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblCategory").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblCategory: function () {
        $("#tblCategory").bootstrapTable('destroy');
        $("#tblCategory").bootstrapTable({
            method: 'get',
            url: "/Admin/Categories/GetCategoriesData",
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
                    field: "namec",
                    title: "Tên loại",
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
                            html += '<button class="btn btn-danger btn-sm btnHidden">Ẩn</button>';
                        } else {
                            html += '<button class="btn btn-success btn-sm btnHidden">Hiển thị</button>';
                        }
                        return html;
                    },
                    events: {
                        'click .btnHidden': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái loại sản phẩm này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Categories/ChangeIsHide',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblCategory").bootstrapTable('refresh', { silent: true });
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
                            $('#ipHiddenId').val(row.id);
                            $('#ipNamec').val(row.namec);
                            $('#titleModal').text('Chỉnh sửa loại sản phẩm');
                            $('#modalsAddEdit').modal('show');
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
    categories.init();
});