<?php
include_once "../Model/productsDbh.php";
include_once "../Model/productsDescriptionDbh.php";
$productsDbh = new ProductsDbh();
$pDDbh = new ProductsDescriptionDbh();

//kaldes hvis der skal slettes et produkt
if(isset($_GET['productId'])){
    $id = $_GET['productId'];
    $productsDbh->deleteProduct($id);
    header("location: ../index.php");
}

//Dette er til opret et nyt produkt, og den også tager en dansk description med.
if(isset($_POST['create'])){
    $p = new Product();
    $p->productReference = $_POST['productReference'];
    $p->productPrice = $_POST['productPrice'];

    $pd = new ProductDescription(); 
    $pd->productName = $_POST['productName'];
    $pd->productShortDesc = $_POST['shortDesc'];
    $pd->productLongDesc = $_POST['longDesc'];

    $productsDbh->createProduct($p, $pd);
    header("location: ../index.php");
}

//til oprettelse af en productdescription, hvor der skal bruges både produktid og languageid.
if(isset($_POST['desc'])){
    $pd = new ProductDescription(); 
    $id = $_POST['productId'];
    $languageId = $_POST['lang'];
    $pd->productName = $_POST['productName'];
    $pd->productShortDesc = $_POST['shortDesc'];
    $pd->productLongDesc = $_POST['longDesc'];

    $pDDbh->createProductDescription($id, $languageId, $pd);
    header("location: updateProduct.php?id=" . $id);
}

//denne er til at opatrere produkterne samt alle deres descriptions
if(isset($_POST['updateall'])){
    $product = $productsDbh->getProductByIdWithDescription($_POST['productId']);
    $product->productId = $_POST['productId'];
    $product->productReference = $_POST['productReference'];
    $product->productPrice = $_POST['productPrice'];

    //Et for  loop til at opfange alle de forskellige produktDescription der skulle være på produktet
    for($i = 0; $i <= sizeof($product->detailList); $i++){
        foreach($product->detailList as $detail){
        if($detail->productDetailId == $_POST['productDetailId'][$i]){
            //$detail->productDetailId = $_POST['productDescriptionId'];
            $detail->productName = $_POST['productName'][$i];
            $detail->productShortDesc = $_POST['shortDesc'][$i];
            $detail->productLongDesc = $_POST['longDesc'][$i];
            }
        }
    }

    $productsDbh->updateProduct($product);
    header("location: updateProduct.php?id=" . $product->productId);
}

