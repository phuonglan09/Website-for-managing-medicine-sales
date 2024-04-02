var booking = {
    init: function () {
        booking.tblBooking();
        $('#btnCreate').click(function () {
            $('#ipHiddenId').val(0);
            $('#ipFullName').val('');
            $('#ipEmail').val('');
            $('#ipPhone').val('');
            $('#ipRequire').val('');
            $('#ipTimebooking').val('');
            $('#titleModal').text('Thêm lịch hẹn');
            $('#modalsAddEdit').modal('show');
        });
        $('#btnSubmit').click(function () {
            $.ajax({
                url: '/Admin/Booking/CreateOrEdit',
                type: 'post',
                dataType: 'json',
                data: $('#frmBooking').serialize(),
                success: function (res) {
                    if (res.status) {
                        base.success(res.message);
                        $("#tblBooking").bootstrapTable('refresh', { silent: true });
                        $('#modalsAddEdit').modal('hide');
                    } else {
                        base.error(res.message);
                    }
                }
            });
        });
    },
    tblBooking: function () {
        $("#tblBooking").bootstrapTable('destroy');
        $("#tblBooking").bootstrapTable({
            method: 'get',
            url: "/Admin/Booking/GetBookingListAll",
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
                    title: "Tên khách hàng",
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
                    field: "email",
                    title: "Email",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "require",
                    title: "Ghi chú",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "timebooking",
                    title: "Lịch đặt",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value != null && value != undefined && value != '') {
                            html += moment(value).format('MM/DD/YYYY HH:mm');
                        }
                        return html;
                    }
                },
                {
                    field: "completed",
                    title: "Trạng thái",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == true) {
                            html += '<button class="btn btn-danger btn-sm btnComplete">Đã duyệt</button>';
                        } else {
                            html += '<button class="btn btn-success btn-sm btnComplete">Chờ xử lý</button>';
                        }
                        return html;
                    },
                    events: {
                        'click .btnComplete': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn thay đổi trạng thái lịch đặt này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Booking/ChangeIsComplete',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblBooking").bootstrapTable('refresh', { silent: true });
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
                            $('#ipFullName').val(row.name);
                            $('#ipEmail').val(row.email);
                            $('#ipPhone').val(row.phone);
                            $('#ipRequire').val(row.require);
                            $('#ipTimebooking').val(moment(row.timebooking).format('YYYY-MM-DDTHH:mm'));
                            $('#titleModal').text('Chỉnh sửa lịch hẹn');
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
    booking.init();
});