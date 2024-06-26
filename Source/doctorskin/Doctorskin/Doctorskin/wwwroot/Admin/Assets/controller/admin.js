﻿var admin = {
    init: function () {
        admin.tblAdmin();
        $('#btnSeach').click(function () {
            admin.tblAdmin();
        });
        $('#btnCreate').click(function () {
            $('#ipHiddenId').val(0);
            $('#ipFullName').val('');
            $('#ipPhone').val('');
            $('#ipUsername').val('').prop("readonly", false);
            $('#ipPassword').val('');
            $('#ipAddress').val('');
            $('#sltRoleGroup').val(0);
            $('#titleModal').text('Thêm mới nhân viên');
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            $.ajax({
                url: '/Admin/Admin/CreateOrEdit',
                type: 'post',
                dataType: 'json',
                data: $('#frmAdmin').serialize(),
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblAdmin").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblAdmin: function () {
        $("#tblAdmin").bootstrapTable('destroy');
        $("#tblAdmin").bootstrapTable({
            method: 'get',
            url: "/Admin/Admin/GetAdminData",
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
                    field: "fullName",
                    title: "Họ và tên",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "phone",
                    title: "Số điện thoại",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "address",
                    title: "Địa chỉ",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "username",
                    title: "Tài khoản",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "roleGroupName",
                    title: "Quyền",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "isActive",
                    title: "Trạng thái",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<button class="btn btn-success btn-sm btnActive">Kích hoạt</button>';
                        } else {
                            html += '<button class="btn btn-danger btn-sm btnActive">Ngừng hoạt động</button>';
                        }
                        return html;
                    },
                    events: {
                        'click .btnActive': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái nhân viên này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Admin/ChangeIsActive',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblAdmin").bootstrapTable('refresh', { silent: true });
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
                            $('#ipFullName').val(row.fullName);
                            $('#ipPhone').val(row.phone);
                            $('#ipUsername').val(row.username).prop("readonly", true);
                            $('#ipPassword').val('');
                            $('#ipAddress').val(row.address);
                            $('#sltRoleGroup').val(row.roleGroupId);
                            $('#titleModal').text('Chỉnh sửa nhân viên');
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
    admin.init();
});