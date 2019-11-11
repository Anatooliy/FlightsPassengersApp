$(document).ready(function () {
    $('.js-checker').on('click', function () {        
        var $this = $(this);

        var data = {
            FlightId: $this.data('flightid'),
            PassengerId: $this.data('passid'),
            IsChecked: $this.is(':checked')
        }
        console.log(JSON.stringify(data));
        $.ajax({
            url: 'http://localhost:59318/api/Flights/' + data.FlightId,
            type: 'PUT',            
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(data),
            success: function (results) {
                
            }
        })
    });
});