// globals
const productsUrl = '/api/products';

// calculator functionality
function setupCalculator() {
    const form = $('#annualCostForm');
    form.submit(onFormSubmit);
    const resultGrid = $('#resultTable tbody');

    // call the estimate api with ajax
    function onFormSubmit(evt) {
        evt.preventDefault();

        const consumption = parseFloat($('#txtConsumption').val());
        if (isNaN(consumption)) {
            return;
        }

        // call api to calculate annual cost
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
            <td>€ ${estimated.annualCost}</td>
        </tr>`;
    }
}

// product grid functionality
function setupProductGrid() {
    const productGrid = $('#productsTable tbody');
    const productForm = $('#productEditForm');
    productForm.submit(onProductSubmit);
    reloadProducts();

    // get products from the api
    function reloadProducts() {
        $.get(`${productsUrl}/`, onProductsResponse);
    }

    // handle produts response
    function onProductsResponse(productsData) {
        let newGridHtml = '';

        if (productsData) {
            for (var i = 0; i < productsData.length; i++) {
                newGridHtml += createProductRow(productsData[i]);
            }
        }

        productGrid.html(newGridHtml);
    }

    // create an html row for a product
    function createProductRow(product) {
        let rowHtml = `<tr>
            <td>${product.id}</td>
            <td>${product.name}</td>
            <td>€ ${product.baseCost}</td>
            <td>€ ${product.addedCost}</td>`;

        if (product.model === 1) {
            rowHtml += `
            <td>Monthly</td>
            <td>-</td>
        </tr>`;
        }
        else if (product.model === 2) {
            rowHtml += `
            <td>Yearly</td>
            <td>${product.threshold} kWh</td>
        </tr>`;
        }
        else {
            rowHtml += `
            <td>-</td>
            <td>-</td>
        </tr>`;
        }

        return rowHtml;
    }

    // handle submit product
    function onProductSubmit(evt) {
        evt.preventDefault();

        const formData = readFormData();

        // send form data to api
        $.ajax({
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            dataType: 'json',
            url: productsUrl,
            success: afterProductSubmit
        });
    }

    // create request object
    function readFormData() {
        return {
            name: $('#txtName').val(),
            baseCost: parseFloat($('#txtBaseCost').val()),
            addedCost: parseFloat($('#txtAddedCost').val()),
            threshold: parseFloat($('#txtThreshold').val()),
            model: parseInt($('input[name=model]:checked', '#productEditForm').val())
        };
    }

    // handle post response
    function afterProductSubmit(data) {
        productForm.trigger("reset");
        reloadProducts();
    }
}