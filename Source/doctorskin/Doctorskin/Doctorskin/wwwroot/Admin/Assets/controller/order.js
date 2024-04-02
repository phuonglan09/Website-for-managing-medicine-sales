var order = {
    init: function () {
        order.tblOrder();
        order.tblOrderDetai();
        $('#btnSeach').click(function () {
            order.tblOrder();
        });
    },
    tblOrder: function () {
        $("#tblOrder").bootstrapTable('destroy');
        $("#tblOrder").bootstrapTable({
            method: 'get',
            url: "/Admin/Order/GetOrderData",
            queryParams: function (p) {
                var param = $.extend(true, {
                    search: $('#txtSearch').val(),
                    status: $('#sltStatus').val(),
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
                    field: "orderCode",
                    title: "Mã đơn hàng",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        return '<a title="Chi tiết đơn hàng" href="/Admin/Order/OrderDetail?Id=' + row.id + '">' + value + '</a>';
                    }
                },
                {
                    field: "fullName",
                    title: "Khách hàng",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "fullName",
                    title: "Khách hàng",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "orderDate",
                    title: "Ngày đặt hàng",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        return moment(value).format('MM/DD/YYYY HH:mm');
                    }
                },
                {
                    field: "totalAmount",
                    title: "Tổng tiền",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        return accounting.formatMoney(value, "", 0, ",", ".", "%v%s");
                    }
                },
                {
                    field: "address",
                    title: "Địa chỉ",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "status",
                    title: "Trạng thái",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value == 1) {
                            html += '<span class="badge bg-warning">Chờ xử lý</span>';
                        } else if (value == 2) {
                            html += '<span class="badge bg-success">Thành công</span>';
                        } else {
                            html += '<span class="badge bg-danger">Hủy</span>';
                        }
                        return html;
                    },
                },
                {
                    title: "Chức năng",
                    valign: 'middle',
                    align: 'center',
                    class: 'CssAction',
                    formatter: function (value, row, index) {
                        var action = "";
                        action += '<a class=" btn btn-success btn-sm btnSuccess" title="Duyệt"><i class="ri-checkbox-circle-fill"></i></a>\
                        <a class=" btn btn-danger btn-sm btnDanger" title="Hủy"><i class="ri-close-circle-line"></i></a>';
                        return action;
                    },
                    events: {
                        'click .btnSuccess': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn duyệt đơn hàng này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Order/ChangeStatus',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                    status: 2
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblOrder").bootstrapTable('refresh', { silent: true });
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
                        },
                        'click .btnDanger': function (e, value, row, index) {
                            $.confirm({
                                title: 'Cảnh báo!',
                                content: 'Bạn chắc chắn muốn hủy đơn hàng này?',
                                buttons: {
                                    formSubmit: {
                                        text: 'Xác nhận',
                                        btnClass: 'btn btn-primary',
                                        action: function () {
                                            $.ajax({
                                                url: '/Admin/Order/ChangeStatus',
                                                type: 'post',
                                                data: {
                                                    Id: row.id,
                                                    status: 3
                                                },
                                                success: function (res) {
                                                    if (res.status) {
                                                        base.success(res.message);
                                                        $("#tblOrder").bootstrapTable('refresh', { silent: true });
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
    tblOrderDetai: function () {
        $("#tblOrderDetail").bootstrapTable('destroy');
        $("#tblOrderDetail").bootstrapTable({
            method: 'get',
            url: "/Admin/Order/GetOrderDetail",
            queryParams: function (p) {
                var param = $.extend(true, {
                    orderId: $('#ipOrderId').val(),
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
                    field: "productName",
                    title: "Tên sản phẩm",
                    align: 'left',
                    valign: 'left',
                },
                {
                    field: "productImage",
                    title: "Ảnh sản phẩm",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        var html = '';
                        if (value != null && value != undefined && value != '') {
                            html += '<img style="width:50px;height=50px;object-fit:cover" src="/Uploads/' + value + '" />'
                        }
                        return html;
                    }
                },
                {
                    field: "unitPrice",
                    title: "Số tiền",
                    align: 'left',
                    valign: 'left',
                    formatter: function (value, row, index) {
                        return accounting.formatMoney(value, "", 0, ",", ".", "%v%s");
                    }
                },
                {
                    field: "quantity",
                    title: "Số lượng",
                    align: 'left',
                    valign: 'left',
                },

            ],
            onLoadSuccess: function (data) {

            },
        })
    },
}
$(document).ready(function () {
    order.init();
});