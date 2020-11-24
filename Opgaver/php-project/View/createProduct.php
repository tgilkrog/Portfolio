<?php
    include_once "../Controller/productcontroller.php";
?>

<!DOCTYPE html>
<html>
    <header>
        <link rel="stylesheet" href="../style.css">
    </head>
    <body>
    <h1>Opret et nyt Produkt</h1>
    <button id="backBtn" onclick="location.href='../index.php'">Back</button>
    <div id="create">
    <!-- Form til at oprette et nyt produkt, hvor den også kalder en function i vores script -->
    <form name="createForm" action=" " method="POST" onsubmit="return validateForm()" required>
        <h2>Referance:</h2>
        <input type="text" name="productReference" placeholder="Produkt Referance"><br>
        <h2>Produkt Pris</h2>
        <input type="text" name="productPrice" placeholder="Produkt Pris"><br>
        <h1>Opret Dansk detaljer</h1>
        <h2>Navn:</h2>
        <input type="text" name="productName" placeholder="Produkt Navn"><br><br >
        <h2>Kort beskrivelse:</h2>
        <input type="text" name="shortDesc" placeholder="kort Beskrivelse"><br>
        <h2>Lang Beskrivelse</h2>
        <textarea placeholder="Lang Beskrivelse" name="longDesc" style="margin-top: 10px;"></textarea>
        <button type="submit" name="create">Opret Product</button>
    </form>
    </div>
    
    <!-- Dette script tjekker om der skulle være nogle inputs der er tomme og giver besked hvilken man mangler at udfylde-->
    <script>
        function validateForm(){
            var errormessage = "Du mangler at udfylde: \n";
            var errorStyle = "solid 2px red";
            var nonStyle="none";
            
            if (document.forms["createForm"]["productReference"].value == ""){
                errormessage += "-Referance \n";
                document.forms["createForm"]["productReference"].style.border = errorStyle;
            }
            else{
                document.forms["createForm"]["productReference"].style.border = nonStyle;
            }
            if (document.forms["createForm"]["productPrice"].value == ""){
                errormessage += "-Pris \n";
                document.forms["createForm"]["productPrice"].style.border = errorStyle;
            }
            else{
                document.forms["createForm"]["productPrice"].style.border = nonStyle;
            }
            if (document.forms["createForm"]["productName"].value == ""){
                errormessage += "-Navn \n";
                document.forms["createForm"]["productName"].style.border = errorStyle;
            }
            else{
                document.forms["createForm"]["productName"].style.border = nonStyle;
            }
            if (document.forms["createForm"]["shortDesc"].value == ""){
                errormessage += "-Kort Beskrivelse \n";
                document.forms["createForm"]["shortDesc"].style.border = errorStyle;
            }
            else{
                document.forms["createForm"]["shortDesc"].style.border = nonStyle;
            }
            if (document.forms["createForm"]["longDesc"].value == ""){
                errormessage += "-Lang beskrivelse \n";
                document.forms["createForm"]["longDesc"].style.border = errorStyle;
            }
            else{
                document.forms["createForm"]["longDesc"].style.border = nonStyle;
            }

            if(errormessage != "Du mangler at udfylde: \n"){
                alert(errormessage);
                return false;               
            }
        }
    </script>
    </body>
</html>