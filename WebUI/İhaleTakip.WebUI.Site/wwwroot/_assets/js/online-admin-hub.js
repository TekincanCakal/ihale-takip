function createToast(userId, isLogin) {
    let toast = document.createElement("div");
    toast.id = userId;
    toast.classList.add("toast");
    if (isLogin === true) {
        toast.classList.add("bg-success");
    }
    else {
        toast.classList.add("bg-danger");
    }

    let toastBody = document.createElement("div");
    toastBody.classList.add("toast-body");
    toast.appendChild(toastBody)

    toastBody.innerText = "Hoşgeldin " + userId;

    toastContainer.appendChild(toast);

    $("#" + userId).toast("show");

    setTimeout(function () { toast.remove() }, 3000);
}





let updateService = function (message) {
    //$("#ServiceStatus").html(message);
    //createToast(message, true);
};

let userLogout = function (message) {
    console.log("xd");
    location.href = "/Çıkış";
    
};

function onConnectionError(error) {
    if (error && error.message) console.error(error.message);
}

let countConnection = new signalR.HubConnectionBuilder().withUrl('/onlineAdminHub').build();
countConnection.on('updateService', updateService);
countConnection.on('logOut', userLogout);


countConnection.onclose(onConnectionError);
countConnection.start()
    .then(function () {
        console.log('Online Hub Connected');
    })
    .catch(function (error) {
        console.error(error.message);
    });