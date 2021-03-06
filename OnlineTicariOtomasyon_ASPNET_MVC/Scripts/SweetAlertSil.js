var object = { status: false, ele: null };
function conFunction(ev) {
    var evnt = ev;
    if (object.status) { return true; }
    Swal.fire({
        title: 'Silmek istediğinize emin misiniz?',
        text: "Bu işlemi geri alamazsınız!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {
            object.status = true;
            object.ele = evnt;
            evnt.click();
        }
    })
    return object.status;
};