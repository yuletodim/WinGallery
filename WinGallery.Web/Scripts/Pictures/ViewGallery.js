(function () {
    $(window).load(function () {
        setActivePicture();
        $(document).on('click', '.thumb', loadPicture());
    })

    function setActivePicture() {
        debugger
        var firstElement = $('.img-wrapper')[0];
        var firstThumb = $('.thumb')[0];

        $(firstElement).addClass('active');
        $(firstThumb).addClass('active');
    }

    //function loadPicture(e){
    //    $('.thumb active').removeClass('active');
    //    $(this).addClass('active');
    //    var urlPicture = $(this).attr('src');
    //}
})();