 

function Endriti() {
   // alert("Endriti 404!");
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'Your work has been saved',
        showConfirmButton: false,
        timer: 1500
    })
}

function RequestInputMask() {
    //$('#PhoneNumber').inputmask("+999 99 999 999");
}

window.methods = {
    Endriti: function () {

        return Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Your work has been saved',
            showConfirmButton: false,
            timer: 1500
        })
         
    },
    RequestInputMask: function () {

        //return $('#PhoneNumber').inputmask("+999 99 999 999");
        return Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Your work has been saved',
            showConfirmButton: false,
            timer: 1500
        })
    }


}