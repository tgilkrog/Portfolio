<?php
    include "Model/productsDbh.php";
    $productsDbh = new ProductsDbh();
?>

<!DOCTYPE html>
<html>
    <header>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <h2>Opret nyt Produkt</h1> <a href="View/createProduct.php">Opret nyt Produkt</a>
        <br><br>
        <h1>Her er en liste af Produkterne</h1>
        <!-- Her køres en foreach a listen over produkterne, hvor der vises Navn, referance og prisen -->
        <ul class="productsList">
            <?php
                foreach($productsDbh->getAllProducts() as $product){
            ?>
            <li class="productsListItem">
                <h2>
                    <?php
                        echo "Navn: " . $product->productName . ", Referance: " . $product->productReference . ", Pris: " . $product->productPrice . " kr.";
                    ?>
                </h2>
                <!-- Knapper til rediger siden og slet, hvor de begge bruger id fra produktet. -->
                <div class="indexButtons">
                    <a href="View/updateProduct.php?id=<?php echo $product->productId; ?>">Opdater</a>
                    <!-- Ved slet er en simpel lille confirm, hvis man ved et uheld skulle trykke på den forkerte -->               
                    <a href="Controller/productcontroller.php?productId=<?php echo $product->productId; ?>" onclick="return confirm('Er du sikker på at du vil slette: <?php echo $product->productName ?>');" id="del">Slet</a>
                </div>
            </li>
            <?php } ?>
        </ul>
    </body>
</html>