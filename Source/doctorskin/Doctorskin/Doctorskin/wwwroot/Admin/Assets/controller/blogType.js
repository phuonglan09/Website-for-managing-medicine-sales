var blogType = {
    init: function () {
        blogType.tblBlogType();
        blogType.tblBlogDetail();
        $('#btnSeach').click(function () {
            blogType.tblBlogType();
            blogType.tblBlogDetail();
        });
        $('#btnCreate').click(function () {
            $('#ipHiddenId').val(0);
            $('#ipNamebt').val('');
            $('#titleModal').text('Thêm loại bài viết');
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            $.ajax({
                url: '/Admin/BlogType/CreateOrEdit',
                type: 'post',
                dataType: 'json',
                data: $('#frmBlogType').serialize(),
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblBlogType").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
        $('#btnSubmitBlogDetail').click(function () {
            var formData = new FormData();
            formData.append("Id", $('#ipIdHidden').val());
            formData.append("BlogTypeId", $('#sltBlogTypeId').val());
            formData.append("Title", $('#ipTitle').val());
            formData.append("Shortcontent", $('#ipShortcontent').val());
            var fileUpload = $("#ipFileUpload").get(0);
            var files = fileUpload.files;
            formData.append("fileUpload", files[0]);
            var desc = CKEDITOR.instances['TxtDescription'].getData();
            formData.append('Contentblog', desc);
            $.ajax({
                url: '/Admin/BlogType/CreateOrEditBlog',
                type: 'post',
                processData: false,
                contentType: false,
                data: formData,
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        setTimeout(function () {
                            window.location.href = '/Admin/BlogType/Blog';
                        }, 1500);
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblBlogType: function () {
        $("#tblBlogType").bootstrapTable('destroy');
        $("#tblBlogType").bootstrapTable({
            method: 'get',
            url: "/Admin/BlogType/GetDataBlogType",
            queryParams: function (p) {
                var param = $.extend(true, {
                    search: $('#txtSearch').val()
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
                    field: "namebt",
                    title: "Tên loại bài viết",
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
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái nhãn hiệu này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/BlogType/ChangeIsHide',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBlogType").bootstrapTable('refresh', { silent: true });
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
                            $('#ipNamebt').val(row.namebt);
                            $('#titleModal').text('Chỉnh sửa loại bài viết');
                            $('#modalsAddEdit').modal('show');
                        },
                    }
                },

            ],
            onLoadSuccess: function (data) {

            },
        })
    },
    tblBlogDetail: function () {
        $("#tblBlogDetail").bootstrapTable('destroy');
        $("#tblBlogDetail").bootstrapTable({
            method: 'get',
            url: "/Admin/BlogType/GetBlogData",
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
                    field: "namebt",
                    title: "Loại bài viết",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "title",
                    title: "Tiêu đề",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "shortcontent",
                    title: "Mô tả ngắn",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "cardimg",
                    title: "Ảnh đại diện",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value != null && value != undefined && value != '') {
                            html += '<img style="width:50px;height=50px;object-fit:cover" src="/Uploads/Blogs/' + value + '" />'
                        }
                        return html;
                    }
                },
                {
                    field: "hideblog",
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
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái bài viết này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/BlogType/ChangeIsHideBlog',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBlogDetail").bootstrapTable('refresh', { silent: true });
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
                        action += '<a class=" btn btn-primary btn-sm btnEdit" href="/Admin/BlogType/CreateOrEditBlog?Id=' + row.id + '" title="Sửa"><i class="bx bx-pencil"></i></a>';
                        return action;
                    },
                    events: {
                        'click .btnEdit': function (e, value, row, index) {
                            $('#ipHiddenId').val(row.id);
                            $('#ipNamebt').val(row.namebt);
                            $('#titleModal').text('Chỉnh sửa loại bài viết');
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
    blogType.init();
});