var roleGroup = {
    init: function () {
        roleGroup.tblRoleGroup();
        $('#btnSeach').click(function () {
            roleGroup.tblRoleGroup();
        });
        $('#btnCreate').click(function () {
            $('#ipHiddenId').val(0);
            $('#ipName').val('');
            $('#titleModal').text("Thêm nhóm quyền");
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            $.ajax({
                url: '/Admin/RoleGroup/CreateOrEdit',
                type: 'post',
                dataType: 'json',
                data: $('#frmRoleGroup').serialize(),
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblRoleGroup").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblRoleGroup: function () {
        $("#tblRoleGroup").bootstrapTable('destroy');
        $("#tblRoleGroup").bootstrapTable({
            method: 'get',
            url: "/Admin/RoleGroup/GetRoleGroupData",
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
                    field: "name",
                    title: "Tên nhóm quyền",
                    align: 'left',
                    valign: 'left',
                },
                {
                    title: "Chức năng",
                    valign: 'middle',
                    align: 'center',
                    class: 'CssAction',
                    formatter: function (value, row, index) {
                        var action = "";
                        action += '<a class=" btn btn-primary btn-sm btnEdit" title="Sửa"><i class="bx bx-pencil"></i></a>\
                            <a class="btn btn-success btn-sm" title="Chi tiết" href="/Admin/Role?Id='+ row.id + '"><i class="ri-list-settings-line"></i></a>';
                        return action;
                    },
                    events: {
                        'click .btnEdit': function (e, value, row, index) {
                            $('#ipHiddenId').val(row.id);
                            $('#ipName').val(row.name);
                            $('#titleModal').text("Chỉnh sửa nhóm quyền");
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
    roleGroup.init();
});