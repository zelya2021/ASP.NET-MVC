
    $(document).ready(() => {
                //объект для чтения изображения
                var reader = new FileReader();

    //событие, которое срабатывает при вызове функции 'readAsDataURL'
                reader.onload = function (e) {
                    var image = e.srcElement.result;
    $('#img-preview').attr('src', image);
};
//событие изменения input[type=file]
                $('input[type=file]').change(function () {
                    var file = this.files[0];
    reader.readAsDataURL(file);
});
});
