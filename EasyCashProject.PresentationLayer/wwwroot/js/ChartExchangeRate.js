$(document).ready(function () {
    $.ajax({
        url: '/Dashboard/Chart',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log('AJAX başarılı, veri:', data); // Veriyi kontrol edin

            // Veriyi alıp grafikte kullanın
            var exchangeKeys = data.exchangeKey;
            var exchangeValues = data.exchangeValue;

            console.log('Döviz Birimleri:', exchangeKeys);
            console.log('Döviz Kurları:', exchangeValues);

            // Chart.js ile grafik oluşturma işlemleri
            var ctx = document.getElementById('exchangeChart').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'pie', // Pie grafik tipi
                data: {
                    labels: exchangeKeys,
                    datasets: [{
                        label: 'Döviz Kurları',
                        data: exchangeValues,
                        backgroundColor: [
                           
                            '#36A2EB', // Mavi
                         
                        ],
                        borderColor: [
                           
                            '#4BC0C0', // Yeşil
                            
                        ],
                        borderWidth: 2
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'top',
                        },
                        tooltip: {
                            callbacks: {
                                label: function (context) {
                                    return context.label + ': ' + context.raw.toFixed(2);
                                }
                            }
                        }
                    }
                }
            });
        },
        error: function (xhr, status, error) {
            console.error('AJAX Hatası:', status, error);
        }
    });
});