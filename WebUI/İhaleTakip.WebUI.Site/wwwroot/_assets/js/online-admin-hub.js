function createToast(userId, isLogin) {
    let toastContainer = document.querySelector(".toast-container");

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
    toastBody.classList.add("text-white");
    toast.appendChild(toastBody)

    if (isLogin === true) {
        toastBody.innerHTML = "<span class='fw-bold'>"+userId+"</span> Sisteme Giriş Yaptı.";
    }
    else {
        toastBody.innerHTML = "<span class='fw-bold'>"+userId+"</span> Sistemden Çıkış Yaptı.";
    }
    

    toastContainer.appendChild(toast);

    $("#" + userId).toast("show");

    setTimeout(function () { toast.remove() }, 3000);
}




let userLoginLogout = function (userId, isLogin){
    createToast(userId, isLogin);
}

let updateService = function (message) {
    document.getElementById("ServiceStatus").innerHTML = message;
};

let forceLoginLogout = function (message) {
    location.href = "/Cikis";
};

function onConnectionError(error) {
    if (error && error.message) console.error(error.message);
}

let onlineAdminHubConnection = new signalR.HubConnectionBuilder().withUrl('/onlineAdminHub').build();
onlineAdminHubConnection.on('updateService', updateService);
onlineAdminHubConnection.on('userLoginLogout', userLoginLogout);
onlineAdminHubConnection.on('forceLoginLogout', forceLoginLogout);

onlineAdminHubConnection.onclose(onConnectionError);
onlineAdminHubConnection.start()
    .then(function () {
        console.log('Online Hub Connected');
    })
    .catch(function (error) {
        console.error(error.message);
    });