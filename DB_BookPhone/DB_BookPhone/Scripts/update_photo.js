
    $(document).ready(() => {
                //������ ��� ������ �����������
                var reader = new FileReader();

    //�������, ������� ����������� ��� ������ ������� 'readAsDataURL'
                reader.onload = function (e) {
                    var image = e.srcElement.result;
    $('#img-preview').attr('src', image);
};
//������� ��������� input[type=file]
                $('input[type=file]').change(function () {
                    var file = this.files[0];
    reader.readAsDataURL(file);
});
});
