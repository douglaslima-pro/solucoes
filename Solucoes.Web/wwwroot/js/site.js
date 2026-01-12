window.addEventListener("load", () => {
    const alerts = [...document.getElementsByClassName("alert")]

    alerts.forEach(a => {
        const bootstrapAlert = new bootstrap.Alert(a)

        setTimeout(() => {
            bootstrapAlert.close()
        }, 10000)
    })
})

function showAlert(type, message, timeout = 10000) {
    const acceptedTypes = [
        "primary",
        "secondary",
        "success",
        "danger",
        "warning",
        "info",
        "light",
        "dark"
    ]

    if (!acceptedTypes.includes(type)) {
        throw new Error("Type argument passed to function does not match a valid alert type!")
    }

    const alertContainer = document.getElementById("alert-container")

    const alert = document.createElement("div")
    alert.classList.add("alert", `alert-${type}`, "alert-dismissible", "fade")
    alert.setAttribute("role", "alert")
    alert.innerHTML = `
        ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `

    alertContainer.append(alert)

    alert.classList.add("show")

    const bootstrapAlert = new bootstrap.Alert(alert)

    setTimeout(() => {
        bootstrapAlert.close()
    }, timeout)
}