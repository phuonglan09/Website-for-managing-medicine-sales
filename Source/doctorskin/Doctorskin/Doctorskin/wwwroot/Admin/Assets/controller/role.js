var role = {
    init: function () {
        $("#chk_All_New").click(function () {
            $('input:checkbox[data-id=chk_Add_New_Item]').not(this).prop('checked', this.checked);
        });

        $("#chk_All_Edit").click(function () {
            $('input:checkbox[data-id=chk_Edit_Item]').not(this).prop('checked', this.checked);
        });

        $("#chk_All_View").click(function () {
            $('input:checkbox[data-id=chk_View_Item]').not(this).prop('checked', this.checked);
        });

        $("#chk_All_Delete").click(function () {
            $('input:checkbox[data-id=chk_Delete_Item]').not(this).prop('checked', this.checked);
        });
        $("#chk_All_Confirm").click(function () {
            $('input:checkbox[data-id=chk_Confirm_Item]').not(this).prop('checked', this.checked);
        });
        $('#saveChangeData').off().on('click', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Role/UpdateRoleModule",
                data: $('#frmRole').serialize(),
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                dataType: 'json',
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        setTimeout(function () {
                            window.location.href = '/Admin/RoleGroup';
                        }, 1000);
                    } else {
                        base.error(res.message);
                    }
                },
                failure: function (res) {
                    alert(res);
                }
            });
        });
    }
}
$(document).ready(function () {
    role.init();
});