<?php
    include_once "../Model/productsDbh.php";
    include_once "../Model/languagesDbh.php";
    include_once "../Controller/productcontroller.php";

    $userid = $_GET['id'];
    $productsDbh = new ProductsDbh();
    $languagesDbh = new LanguagesDbh();
    //Her hentes produktet med det givne id
    $result = $productsDbh->getProductByIdWithDescription($userid);
    $languages = $languagesDbh->getLanguages();

    //Her oprettes der en array med de sprog som dette produkt ikke har endnu.
    $newArray = $languages; 
    for($i = 0; $i < sizeof($languages); $i++){    
        foreach($result->detailList as $item){    
            if ($item->langName == $languages[$i]->languageName) {
                unset($newArray[$i]);
            }
    }
}
?>

<!DOCTYPE html>
<html>
    <header>
        <link rel="stylesheet" href="../style.css">
    </head>
    <body>
        <div class="content" id="blur">
            <button id="backBtn" onclick="location.href='../index.php'">Back</button>
            <h1>Ændre Produktet</h1>
            <!-- hvis detail list er ligeså stor som lanugages skal tilføj ikke vises, da produktet har en beskrivelse til alle sprog -->
            <?php if(sizeof($result->detailList) < sizeof($languages)){ ?>
            <button id="createBtn" onclick="toggle()">Tilføj sprog</button>
            <?php } ?>
        
            <!-- form til redigereing af et produkt -->
            <form action=" " method="POST">
                <div class="editBox">
                    <input type="hidden" name="productId" value="<?php echo $result->productId?>">
                    <h2>Produkt Reference:</h2>
                    <input type="text" name="productReference" value="<?php echo $result->productReference?>">
                    <br>
                    <h2>Produkt Pris:</h2>
                    <input type="text" name="productPrice" value="<?php echo $result->productPrice?>">
                </div>
                
                <!-- foreach til at vise alle produktdescriptions som produktet har -->
                <ul>
                    <?php foreach($result->detailList as $item){ ?>
                    <li class="descBox">
                        <input type="hidden" name="productDetailId[]" value="<?php echo $item->productDetailId?>">
                        <h2><?php echo "Sprog: " . $item->langName; ?></h2><br>
                        <h2>Produkt Navn: </h2><input type="text" name="productName[]" value="<?php echo $item->productName?>"><br>
                        <h2>Kort Beskrivelse: </h2><input type="text" name="shortDesc[]" value="<?php echo $item->productShortDesc?>"><br>
                        <h2>Lang Beskrivelse: </h2><br>
                        <textarea name="longDesc[]"><?php echo $item->productLongDesc?></textarea><br>
                    </li>
                    <?php } ?>         
                    <div class="editBox">
                        <button type="submit" name="updateall" style="width: 1000px" value="update">Opdater</button>
                    </div>
                </ul>
            </form>
        </div>

        <!-- her kan der oprettes en ny description -->
        <div  id="createDesc" class="descBox createBox">
            <form name="createForm" action=" " method="POST" onsubmit="return validateForm()" required>
                <input type="hidden" name="productId" value="<?php echo $result->productId?>">
                <h2>Vælg Sprog</h2>
                <select name="lang">
                    <?php foreach($newArray as $lang) { ?>
                    <option value="<?php echo $lang->languageId?>"><?php echo $lang->languageName?></option>
                    <?php } ?>
                </select>
                <br>
                <h2>Produkt Navn: </h2><input type="text" name="productName"  placeholder="Navn"><br>
                <h2>Kort Beskrivelse: </h2><input type="text" name="shortDesc" placeholder="Kort Beskrivelse"><br>
                <h2>Lang beskrivelse: </h2><br>
                <textarea name="longDesc" placeholder="Lang Beskrivelse"></textarea><br>
                <button type="submit" name="desc" style="display: inline-block;">Tilføj</button>
            </form>
            
            <button id="del" style="position: fixed; margin-left: 140px; margin-top: -60px;" onclick="toggle()">Fortryd</button>
        </div>

        <script>
        //Denn function toggle() er når der trykkes på opret sprog, kommer der en voks op og bagrunden bliver blørret.
            function toggle(){
                var blur = document.getElementById('blur');
                blur.classList.toggle('active');
                var createBox = document.getElementById('createDesc');
                createBox.classList.toggle('active');
            }

        //denne tjekker at der ikke er tomme felter i opret sprog
        function validateForm(){
            var errormessage = "Du mangler at udfylde: \n";
            var errorStyle = "solid 2px red";
            var nonStyle="none";
            
            //hvis den er tom skal den tilføje det til errormessage og gøre borderen rød.
            if (document.forms["createForm"]["productName"].value == ""){
                errormessage += "-Navn \n";
                document.forms["createForm"]["productName"].style.border = errorStyle;
            }
            //og ellers sættes den tilbage til none
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