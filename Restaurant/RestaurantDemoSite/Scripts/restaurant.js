/*global $ */
/*jslint browser: true, devel: true, plusplus: true, white: true */

var addMenuItemToOrder, calculateSubtotal, clearForm, clickRemove,
    formatRowColor, formatRowCurrency, getRestaurantMenu, handleOrder,
    orderTotal, populateDropdown, tableToJson, sendOrder, serviceUrl,
    serviceHost, servicePort;

(function () {
    "use strict";

    // Construct WCF service address
    serviceHost = location.hostname;
    servicePort = 9250;
    serviceUrl = "http://" + serviceHost + ":" + servicePort + "/RestaurantService.svc/";

    // Execute when the DOM is fully loaded
    $(document).ready(function () {
        getRestaurantMenu();
    });

    // Add selected item to order
    $(function () {
        $("#add_btn").click(addMenuItemToOrder);
    });

    // Place order if it contains items
    $(function () {
        $("#order_btn").click(handleOrder);
    });

    // Retrieve JSON data (menu) and loop for each menu item
    getRestaurantMenu = function () {
        $.ajax({
            cache: true,
            url: serviceUrl + "GetCurrentMenu",
            data: "{}",
            type: "GET",
            jsonpCallback: "RestaurantMenu",
            contentType: "application/javascript",
            dataType: "jsonp",
            error: function () {
                alert("Menu failed!");
            },
            success: function (menu) {
                $.each(menu, populateDropdown); // must call function as var
            }
        });
    };

    // Populate drop-down box with JSON data (menu)
    populateDropdown = function () {
        var id, price, description;
        id = this.Id;
        price = this.Price;
        description = this.Description;
        $("#select_item")
            .append($("<option></option>")
            .val(id)
            .html(description)
            .attr("title", price));
    };

    // Add selected menu item to order table
    addMenuItemToOrder = function () {
        var order_item_selected_quantity, selected_item,
            order_item_selected_id, order_item_selected_description,
            order_item_selected_price, order_item_selected_subtotal;

        // Limit order quantity to between 1-99
        order_item_selected_quantity =
            parseInt($("#select_quantity").val(), 10);

        if (order_item_selected_quantity < 1 ||
        order_item_selected_quantity > 99 ||
        isNaN(order_item_selected_quantity)) {
            $("#select_quantity").focus();
            return;
        }

        // Can't add 'Select an Item...' to order
        if ($("#select_item").get(0).selectedIndex === 0) {
            $("#select_item").focus();
            return;
        }

        // Get values
        selected_item = $("#select_item option:selected");
        order_item_selected_id = parseInt(selected_item.val(), 10);
        order_item_selected_description = selected_item.text();
        order_item_selected_price = parseFloat(selected_item.attr("title"));

        // Calculate subtotal
        order_item_selected_subtotal =
            calculateSubtotal(order_item_selected_price,
            order_item_selected_quantity);

        // Write out menu selection to table row
        $("<tr class='order_row'></tr>").html("<td>" +
            order_item_selected_quantity +
            "</td><td class='order_item_id hidden'>" +
            order_item_selected_id +
            "</td><td class='order_item_name'>" +
            order_item_selected_description +
            "</td><td class='order_item_price'>" +
            order_item_selected_price +
            "</td><td class='order_item_subtotal'>" +
            order_item_selected_subtotal +
            "</td><td><input type='button' value='remove' class='btn btn-danger btn-sm'/></td>")
            .appendTo("#order_cart").hide();

        // Display grand total of order_item_selected_id
        $("#order_cart tr.order_row:last").fadeIn("medium", function () {
            // Callback once animation is complete
            orderTotal();
        });

        formatRowCurrency();
        formatRowColor();
        clickRemove();
        clearForm();
    };

    // Calculate subtotal
    calculateSubtotal = function (price, quantity) {
        return price * quantity;
    };

    // Create alternating colored rows in order table
    formatRowColor = function () {
        $("#order_cart tr.order_row:odd").addClass("info");
        $("#order_cart tr.order_row:even").removeClass("info");
    };

    // Format new order item values to currency
    formatRowCurrency = function () {
        $("#order_cart td.order_item_price:last").formatCurrency();
        $("#order_cart td.order_item_subtotal:last").formatCurrency();
    };

    // Bind a click event to the correct remove button
    clickRemove = function () {
        $("#order_cart tr.order_row:last input").click(function () {
            $(this).parent().parent().children().fadeOut("fast", function () {
                $(this).parent().slideUp("slow", function () { // the row (tr)
                    $(this).remove(); // the row (tr)
                    orderTotal();
                });
            });
        });
    };

    // Clear order input form and re-focus cursor
    clearForm = function () {
        $("#select_quantity").val("");
        $("#select_item option:first-child").attr("selected", "selected");
        $("#select_quantity").focus();
    };

    // Calculate new order total
    orderTotal = function () {
        var order_total = 0;

        $("#order_cart td.order_item_subtotal").each(function () {
            var amount = ($(this).html()).replace("$", "");
            order_total += parseFloat(amount);
        });

        $("#order_total").text(order_total).formatCurrency();
    };

    // Call functions to prepare order and send to WCF service
    handleOrder = function () {
        if ($("#order_cart tr.order_row:last").length === 0) {
            alert("No items selected...");
        } else {
            var data = tableToJson();
            sendOrder(data);
        }
    };

    // Convert HTML table data into an array
    // Based on code from: 
    // http://johndyer.name/post/table-tag-to-json-data.aspx
    tableToJson = function () {
        var data, headers, orderCartTable, myTableRow, rowData, i, j;

        headers = ["Quantity", "Id"];
        data = [];
        orderCartTable = document.getElementById("order_cart");

        // Go through cells
        for (i = 1; i < orderCartTable.rows.length - 1; i++) {
            myTableRow = orderCartTable.rows[i];
            rowData = {};

            for (j = 0; j < 2; j++) {
                rowData[headers[j]] = myTableRow.cells[j].innerHTML;
            }

            data.push(rowData);
        }

        return data;
    };

    // Convert array to JSON and send to WCF service
    sendOrder = function (data) {
        var jsonString = JSON.stringify({ restaurantOrder: data });

        $.ajax({
            url: serviceUrl + "SendOrder?restaurantOrder=" + jsonString,
            type: "GET",
            contentType: "application/javascript",
            dataType: "jsonp",
            jsonpCallback: "OrderResponse",
            error: function () {
                alert("Order failed!");
            },
            success: function (confirmation) {
                alert(confirmation.toString());
            }
        });
    };
}());