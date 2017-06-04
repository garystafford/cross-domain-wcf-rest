/*global $ */
/*jslint browser: true, devel: true, plusplus: true, white: true */

var addMenuItemToOrder,
    calculateSubtotal,
    clearForm,
    clickRemove,
    formatRowColor,
    formatRowCurrency,
    getRestaurantMenu,
    handleOrder,
    orderTotal,
    populateDropdown,
    tableToJson,
    sendOrder,
    serviceUrl,
    serviceHost,
    servicePort;

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
                $("#orderResponse").html(
                    "<p class='h4 callout-danger'>Error</p>" +
                    "Menu failed to load."
                );
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
        var orderItemSelectedQuantity,
            selectedItem,
            orderItemSelectedId,
            orderItemSelectedDescription,
            orderItemSelectedPrice,
            orderItemSelectedSubtotal;

        // Limit order quantity to between 1-99
        orderItemSelectedQuantity =
            parseInt($("#select_quantity").val(), 10);

        if (orderItemSelectedQuantity < 1 ||
            orderItemSelectedQuantity > 99 ||
            isNaN(orderItemSelectedQuantity)) {
            $("#select_quantity").focus();
            return;
        }

        // Can't add 'Select an Item...' to order
        if ($("#select_item").get(0).selectedIndex === 0) {
            $("#select_item").focus();
            return;
        }

        // Get values
        selectedItem = $("#select_item option:selected");
        orderItemSelectedId = parseInt(selectedItem.val(), 10);
        orderItemSelectedDescription = selectedItem.text();
        orderItemSelectedPrice = parseFloat(selectedItem.attr("title"));

        // Calculate subtotal
        orderItemSelectedSubtotal =
            calculateSubtotal(orderItemSelectedPrice,
                orderItemSelectedQuantity);

        // Write out menu selection to table row
        $("<tr class='order_row'></tr>").html("<td>" +
            orderItemSelectedQuantity +
            "</td><td class='order_item_id hidden'>" +
            orderItemSelectedId +
            "</td><td class='order_item_name'>" +
            orderItemSelectedDescription +
            "</td><td class='order_item_price'>" +
            orderItemSelectedPrice +
            "</td><td class='order_item_subtotal'>" +
            orderItemSelectedSubtotal +
            "</td><td class='remove_item'>" +
            "<button class='btn btn-danger btn-xs'>" +
            "<span class='glyphicon glyphicon-remove'></span></button></td>")
            .appendTo("#order_cart").hide();

        // Display grand total of order_item_selected_id
        $("#order_cart tr.order_row:last").fadeIn("medium",
            function () {
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
            $(this).parent().parent().children().fadeOut("fast",
                function () {
                    $(this).parent().slideUp("slow",
                        function () { // the row (tr)
                            $(this).remove(); // the row (tr)
                            orderTotal();
                        });
                });
        });
    };

    // Clear order input form and re-focus cursor
    clearForm = function () {
        $("#select_quantity").val("");
        $("#select_item").val("Select an Item...");
        $("#select_quantity").focus();
    };

    // Calculate new order total
    orderTotal = function () {
        var orderTotal = 0;

        $("#order_cart td.order_item_subtotal").each(function () {
            var amount = ($(this).html()).replace("$", "");
            orderTotal += parseFloat(amount);
        });

        $("#order_total").text(orderTotal).formatCurrency();
    };

    // Call functions to prepare order and send to WCF service
    handleOrder = function () {
        if ($("#order_cart tr.order_row:last").length === 0) {
            $("#orderResponse").html(
                "<p class='h4 callout-danger'>Error</p>" +
                "Your order is empty."
            );
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

        headers = ["Qnt.", "Id", "Description", "Price"];
        data = [];
        orderCartTable = document.getElementById("order_cart");

        // Go through cells
        for (i = 1; i < orderCartTable.rows.length - 1; i++) {
            myTableRow = orderCartTable.rows[i];
            rowData = {};

            for (j = 0; j < 4; j++) {
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
                $("#orderResponse").html(
                    "<p class='h4 callout-danger'>Error</p>" +
                    "Order failed."
                );
            },
            success: function (confirmation) {
                $("#orderResponse").html(
                    "<p class='h4'>Confirmation</p>" +
                    "Time: " +
                    confirmation.OrderTime +
                    "<br />" +
                    "Order Id: " +
                    confirmation.OrderId +
                    "<br />" +
                    "Message: " +
                    confirmation.OrderMessage
                );
            }
        });
    };
}());