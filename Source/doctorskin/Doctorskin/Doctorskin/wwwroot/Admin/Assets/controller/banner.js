var banner = {
    init: function () {
        banner.tblBanner();
        $('#btnCreate').click(function () {
            $('#ipFileUpload').val('');
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            var formData = new FormData();
            var fileUpload = $("#ipFileUpload").get(0);
            var files = fileUpload.files;
            formData.append("fileUpload", files[0]);
            $.ajax({
                url: '/Admin/Banner/CreateOrEdit',
                type: 'post',
                contentType: false,
                processData: false,
                data: formData,
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblBanner").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblBanner: function () {
        $("#tblBanner").bootstrapTable('destroy');
        $("#tblBanner").bootstrapTable({
            method: 'get',
            url: "/Admin/Banner/GetBannerData",
            queryParams: function (p) {
                var param = $.extend(true, {

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
            sidePagination: 'client',
            pagination: true,
            paginationVAlign: 'bottom',
            search: false,
            pageSize: 10,
            pageList: [10, 50, 500],
            columns: [

                {
                    field: "image",
                    title: "Ảnh",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value != null && value != undefined && value != '') {
                            html += '<img style="width:100px;height=100px;object-fit:cover" src="/Uploads/Banner/' + value + '" />'
                        }
                        return html;
                    }
                },

                {
                    field: "homepage",
                    title: "Trang chủ",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<input class="form-check-input btnHomePage" type="checkbox" checked="">';
                        } else {
                            html += '<input class="form-check-input btnHomePage" type="checkbox">';
                        }
                        return html;
                    },
                    events: {
                        'click .btnHomePage': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái banner trang chủ?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Banner/ChangeIsHome',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBanner").bootstrapTable('refresh', { silent: true });
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
                    field: "servicepage",
                    title: "Trang dịch vụ",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<input class="form-check-input btnServicepage" type="checkbox" checked="">';
                        } else {
                            html += '<input class="form-check-input btnServicepage" type="checkbox">';
                        }
                        return html;
                    },
                    events: {
                        'click .btnServicepage': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái banner trang dịch vụ?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Banner/ChangeIsServicepage',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBanner").bootstrapTable('refresh', { silent: true });
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
                    field: "blogpage",
                    title: "Trang blog",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<input class="form-check-input btnBlogpage" type="checkbox" checked="">';
                        } else {
                            html += '<input class="form-check-input btnBlogpage" type="checkbox">';
                        }
                        return html;
                    },
                    events: {
                        'click .btnBlogpage': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái banner trang tin tức?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Banner/ChangeIsBlogpage',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBanner").bootstrapTable('refresh', { silent: true });
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
                    field: "productpage",
                    title: "Trang sản phẩm",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<input class="form-check-input btnProductpage" type="checkbox" checked="">';
                        } else {
                            html += '<input class="form-check-input btnProductpage" type="checkbox">';
                        }
                        return html;
                    },
                    events: {
                        'click .btnProductpage': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái banner trang sản phẩm?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Banner/ChangeIsProductpage',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBanner").bootstrapTable('refresh', { silent: true });
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
                        action += '<a class=" btn btn-danger btn-sm btnDelete" title="Xóa"><i class="ri-delete-bin-2-line"></i></a>';
                        return action;
                    },
                    events: {
                        'click .btnDelete': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn xóa banner nàyy?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Banner/Delete',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBanner").bootstrapTable('refresh', { silent: true });
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

            ],
            onLoadSuccess: function (data) {

            },
        })
    },
}
$(document).ready(function () {
    banner.init();
});