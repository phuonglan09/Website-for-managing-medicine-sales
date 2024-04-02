var cart = {
    init: function () {

    },
    adjustQuantity: function (_this) {
        _this = $(_this);
        var input = _this.parents('.quantity-block').find('input');
        var quantity = input.val();
        var adjust = _this.data('value');
        adjust = parseInt(adjust) || 0;
        quantity = parseInt(quantity) || 0;
        if ((adjust != 1 && adjust != -1) || quantity + adjust <= 0) return;
        quantity += adjust;
        input.val(quantity).trigger('change');
    },
    updateCart: function (productId) {
        var quantityPro = $('#ipQuantitypro-' + productId).val();
        $.ajax({
            url: '/Cart/UpdateCart',
            type: 'post',
            dataType: "json",
            data: {
                productId: productId,
                quantity: quantityPro
            },
            success: function (res) {
                if (res.status) {
                    location.reload();
                }
                else {
                    base.error(res.message);
                }
            },
            error: function () {
                base.error('Có lỗi xảy ra vui lòng thử lại');
            }
        })
    },
    deleteCart: function (productId) {
        $.ajax({
            url: '/Cart/DeleteCart',
            type: 'post',
            dataType: "json",
            data: {
                productId: productId,
            },
            success: function (res) {
                if (res.status) {
                    location.reload();
                }
                else {
                    base.error(res.message);
                }
            },
            error: function () {
                base.error('Có lỗi xảy ra vui lòng thử lại');
            }
        })
    }
}
$(document).ready(function () {
    cart.init();
});