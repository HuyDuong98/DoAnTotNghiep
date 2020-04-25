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
    $(document).on("keydown", "#txtPhoneNumber", function (e) {
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