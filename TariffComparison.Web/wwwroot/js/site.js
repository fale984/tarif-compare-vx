// globals
const productsUrl = "/api/products";

// calculator functionality
function setupCalculator() {
    const form = $('#annualCostForm');
    form.submit(onFormSubmit);
    const resultGrid = $("#resultTable tbody");

    // call the estimate api with ajax
    function onFormSubmit(evt) {
        evt.preventDefault();

        const consumption = parseFloat($('#txtConsumption').val());
        if (isNaN(consumption)) {
            return;
        }

        // call api
        $.get(`${productsUrl}/estimate/${consumption}`, onEstimateResponse);
    }

    // handle estimate response
    function onEstimateResponse(estimateData) {
        let newGridHtml = '';

        // add result
        if (estimateData) {
            for (var i = 0; i < estimateData.length; i++) {
                newGridHtml += createEstimateRow(estimateData[i]);
            }
        }

        resultGrid.html(newGridHtml);
    }

    // create an html row for the estimation result
    function createEstimateRow(estimated) {
        return `<tr>
            <td>${estimated.id}</td>
            <td>${estimated.name}</td>
            <td>${estimated.annualCost}</td>
        </tr>`;
    }
}