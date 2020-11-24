<?php
include_once "Dbh.php";
include_once "productsClasses.php";

class ProductsDescriptionDbh extends Dbh{
  
    //Denne opretter en ny ProductsDescription i databasen med de givne værdier.
    public function createProductDescription($productId, $languageId, $pd){
        $sql ="INSERT INTO products_description(products_id, languages_id, products_description_name, 
        products_description_short_description, products_description_description) VALUES(?, ?, ?, ?, ?)";
        $stmt = $this->connect()->prepare($sql);
        $stmt->execute([(int)$productId, (int)$languageId, $pd->productName, $pd->productShortDesc, $pd->productLongDesc]);
    }
}