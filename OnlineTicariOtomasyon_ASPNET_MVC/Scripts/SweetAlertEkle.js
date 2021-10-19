var object = { status: false, ele: null };
function conFunction(ev) {
    var evnt = ev;
    if (object.status) { return true; }
    Swal.fire({
        title: 'Eklemek istiyor musunuz?',
        text: "",
        icon: 'success',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Ekle',
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