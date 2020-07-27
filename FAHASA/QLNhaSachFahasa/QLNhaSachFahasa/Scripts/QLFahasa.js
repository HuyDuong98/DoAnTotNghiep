function checkInput(idSearch, ico) {
    if ($(idSearch).val() != '') {
        $(ico).removeClass('fa-search').addClass('fa-times')
    }
    else {
        $(ico).addClass('fa-search').removeClass('fa-times')
    }
}
function deleteValInput(idSearch, ico, idInput) {
    $(ico).on('click', function () {
        $(idInput).val('')
        checkInput(idSearch, ico)
        $(idSearch).addClass("active");
        $(idInput).blur(function () {
            $(idSearch).removeClass("active");
        })
    })
}
function addclassFocus(idInput, idSearch) {
    $(idInput).focus(function () {
        $(idSearch).addClass("active");
    })
    $(idInput).blur(function () {
        $(idSearch).removeClass("active");
    })
}
function initKeydownNumber() {
    $(document).on("keydown", "#txtPhoneNumber, #input-money, #input-number, #input-money-2, #CMND", function (e) {
        if (e.keyCode === 110 || e.keyCode === 190)
            e.preventDefault();

        if ($(this).val().indexOf('.') !== -1 && e.keyCode === 190)
            e.preventDefault();

        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40) || e.keyCode === 190) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            //$(this).val("");
            e.preventDefault();
        }
    })
}

function showError(message) {
    $('.popup').remove();
    var div =
        '<div id="error" style="display:none;" class="popup alert-danger alert">' +
        '<a class="close" data-dismiss="alert" href="#">&times;</a>' +
        '<h4 class="alert-heading">Warning!</h4>' +
        '<div id="error-content">' + message + '</div>' +
        '</div>';
    $('body').append(div);
    $('#error').show('shake');
    //setTimeout(function () { $('.popup').remove(); }, 10000);
    //setTimeout(function () {
    //    $('.popup').hide('fast');
    //    $('.popup').remove();
    //}, 10000);
}
function showSuccessOrder() {
    $(".text-mesage-order").remove();
    $(".message-cart").append('<span class="text-mesage-order">Đã thêm sản phẩm vào giỏ hàng!</span>');
    $(".message-cart").show();
    setTimeout(function () {
        $(".message-cart").hide('fast');
        $(".text-mesage-order").remove();
    }, 5000);
}
function showSuccess(message) {
    $('.popup').remove();
    var div =
        '<div id="success" style="display:none;" class="popup alert-success alert">' +
        '<a class="close" data-dismiss="alert" href="#">&times;</a>' +
        '<div id="error-content">' + message + '</div>' +
        '</div>';
    $('body').append(div);
    $('#success').show();
    setTimeout(function () {
        $('.popup').hide('fast');
        $('.popup').remove();
    }, 10000000);
}
function clearForms() {
    $(':input').not(':button, :submit, :reset, :hidden, :checkbox, :radio').val('');
    $(':checkbox, :radio').prop('checked', false);
}


function fixedHeaderBg() {
    var $headerOfPage = $('.header-of-page');
    var winWidth = $(window).width();
    var $head = $('.header-content');
    var top = $(window).scrollTop();
    if (winWidth > 999) {
        if (top >= 1) {
            $headerOfPage.addClass('bg-color').css({ "boxShadow": "rgb(220, 220, 220) 0 2px 10px" });
            $(".header-of-page-mobie").addClass('bg-color').css({ "boxShadow": "rgb(220, 220, 220) 0 2px 10px" });
            $('.en-link').css({ "color": "#5C5758" });
            $head.removeClass('black-bg');
            $('.header-of-page .header-content').css("padding", "12px 0");
        } else {
            $headerOfPage.removeClass('bg-color').css({ "boxShadow": "none" });
            $(".header-of-page-mobie").removeClass('bg-color').css({ "boxShadow": "none" });
            $head.addClass('black-bg');
            $('.en-link').css({ "color": "#fff" });
            $('.header-of-page .header-content').css("padding", "22px 0");
        }
    } else {
        if (top >= 1) {
            $headerOfPage.addClass('bg-color').css({ "boxShadow": "rgb(220, 220, 220) 0 2px 10px" });
            $(".header-of-page-mobie").addClass('bg-color').css({ "boxShadow": "rgb(220, 220, 220) 0 2px 10px" });
            $head.removeClass('black-bg');
            $('.header-of-page .header-content').css("padding","12px 0");
        } else {
            $headerOfPage.removeClass('bg-color').css({ "boxShadow": "none" });
            $(".header-of-page-mobie").removeClass('bg-color').css({ "boxShadow": "none" });
            $head.addClass('black-bg');
            $('.header-of-page .header-content').css("padding", "22px 0");
        }
    }
}
function initDialog(title, content, contentBtnCancel = '') {
    
    $('#dialog').kendoDialog({
        width: "450px",
        title: title,
        closable: false,
        visible: false,
        content: " <span class='k-icon k-i-info'></span>" +content,
        buttonLayout: "normal",
        actions: [
            { text: contentBtnCancel },
        ]
    });
    $('#dialog').data("kendoDialog").open().element.closest(".k-window").css({ top: 40 });
}
