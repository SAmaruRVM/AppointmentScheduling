$(document).ready(function () {
    initCalendar();
});

function initCalendar() {
    try {
        $('#calendar').fullCalendar
            (
                {
                    timezone: false,
                    header: {
                        left: 'prev, next,today',
                        center: 'title',
                        right: 'month,agendaWeek,agendaDay'
                    },
                    selectable: true,
                    editable: false,
                    select: function (event)
                    {
                        onShowModal(event, null);
                    }
                });
    }
    catch (e) {
        alert(e);
    }
}


function onShowModal(event, isEventDetails)
{
    $("#appointmentInput").modal("show");
}
//window.addEventListener("click", () =>
//{
//    $('#appointmentInput').modal('hide');
//})
