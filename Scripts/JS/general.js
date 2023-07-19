$(document).ready(function () {
    let employeesData;
    $.ajax({
        url: "/Home/GetEmployees",
        type: "GET",
        dataType: "json",
        success: function (data) {
            employeesData = data;
            displayEmployees(data);
        },
        error: function (error) {
            console.log("Error when obtain user info: ", error);
        }
    });

    function displayEmployees(employees) {
        let tableRows = '';

        employees.forEach(employee => {
            tableRows += `
        <tr>
          <td>${employee.id}</td>
          <td>${employee.employee_name}</td>
          <td>${employee.employee_salary}</td>
          <td>${employee.employee_salary * 12}</td>
          <td>${employee.employee_age}</td>
          <td>${employee.profile_image}</td>
          <td><button onclick="getUser(${employee.id});" class="btn btn-primary btnViewProfile" data-id="${employee.id}">View employee</button></td>
        </tr>
      `;
        });

        $("#employeeTableBody").html(tableRows);

        $("#employeeTable").DataTable({
            "language": {
                "search": "Search employee"
            },
            "columnDefs": [
                {
                    "targets": [2, 3, 4, 5],
                    "searchable": false 
                }
            ]
        });
    }

    $(".btnViewProfile").on("click", function () {
        var userId = $(this).data("id");
        alert(userId);
        $.ajax({
            url: "/Home/GetEmployee",
            type: "GET",
            data: { id: userId },
            dataType: "json",
            success: function (data) {
                alert("entra");
                $("#Name").text(data.employee_name);
                $("#Salary").text(data.employee_salary);
                $("#AnualSalary").text(data.employee_salary * 12);
                $("#Age").text(data.employee_age);
                $("#Image").text(data.profile_image);
                $("#userModal").modal("show");
            },
            error: function (error) {
                console.log("Error when obtain user info: ", error);
            }
        });
    });
});

function getUser(id) {
    $.ajax({
        url: "/Home/GetEmployee",
        type: "GET",
        data: { id: id },
        dataType: "json",
        success: function (data) {
            $("#Name").text(data.employee_name);
            $("#Salary").text(data.employee_salary);
            $("#AnualSalary").text(data.employee_salary * 12);
            $("#Age").text(data.employee_age);
            $("#Image").text(data.profile_image);
            $("#userModal").modal("show");
        },
        error: function (error) {
            console.log("Error when obtain user info: ", error);
        }
    });
}