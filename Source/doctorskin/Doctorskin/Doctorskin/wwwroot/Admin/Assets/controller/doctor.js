var doctor = {
    init: function () {
        doctor.tblDoctor();
        $('#btnSeach').click(function () {
            doctor.tblDoctor();
        });
        $('#btnCreate').click(function () {
            $('#ipHiddenId').val(0);
            $('#ipNameDoc').val('');
            $('#txtInfoDoc').val('');
            $('#ipFileUpload').val('');
            $('#titleModal').text("Thêm mới bác sĩ");
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            var formData = new FormData();
            formData.append("Id", $('#ipHiddenId').val());
            formData.append("Namedoc", $('#ipNameDoc').val());
            formData.append("Infordoc", $('#txtInfoDoc').val());
            var fileUpload = $("#ipFileUpload").get(0);
            var files = fileUpload.files;
            formData.append("fileUpload", files[0]);
            $.ajax({
                url: '/Admin/Doctor/CreateOrEdit',
                type: 'post',
                contentType: false,
                processData: false,
                data: formData,
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblDoctor").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblDoctor: function () {
        $("#tblDoctor").bootstrapTable('destroy');
        $("#tblDoctor").bootstrapTable({
            method: 'get',
            url: "/Admin/Doctor/GetDoctorData",
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
                    field: "namedoc",
                    title: "Tên",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "avaDoc",
                    title: "Ảnh",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value != null && value != undefined && value != '') {
                            html += '<img style="width:50px;height=50px;object-fit:cover" src="/Uploads/Doctor/' + value + '" />'
                        }
                        return html;
                    }
                },
                {
                    field: "infordoc",
                    title: "Thông tin bác sĩ",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "hideDoc",
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
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái bác sĩ này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Doctor/ChangeIsHide',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblDoctor").bootstrapTable('refresh', { silent: true });
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
                            $('#ipNameDoc').val(row.namedoc);
                            $('#txtInfoDoc').val(row.infordoc);
                            $('#ipFileUpload').val('');
                            if (row.avaDoc != null && row.avaDoc != '' && row.avaDoc != undefined) {
                                var html = '<img src="/Uploads/Doctor/' + row.avaDoc + '" alt="avatar" class="mt-1" width="80" height="60" />';
                                $('#lblImage').html(html);
                            }
                            $('#titleModal').text("Chỉnh sửa bác sĩ");
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
    doctor.init();
});