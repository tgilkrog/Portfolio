<?php
include_once "Dbh.php";
include_once "productsClasses.php";

class ProductsDbh extends Dbh{

    //Her hentes listen a produkter til index.php siden.
    public function getAllProducts(){
        $products = array();
        //den henter også products_description languages_id med id = 1, da det altid er det danske navn vi skal bruge.
        $sql = "SELECT * FROM products JOIN products_description as pd on (products.products_id = pd.products_id) WHERE pd.languages_id = 1";
        $stmt = $this->connect()->query($sql);
        $result = $stmt->fetchAll();
        foreach ( $result as $row ){  
            $product = new Product();  
            $product->productId= $row[ 'products_id' ];  
            $product->productReference = $row[ 'products_reference' ];  
            $product->productPrice = $row[ 'products_price' ];
            $product->productName = $row['products_description_name'];   

            array_push( $products, $product );  
        }
        return $products;
    }

    //Denne bruges til rediger siden, da vi skal bruge alle product_description som det givne produkt har.
    public function getProductByIdWithDescription($productId){
        $productList = array();
        $sql = "Select * FROM products JOIN products_description as pd on (products.products_id = pd.products_id) JOIN languages as l on (l.languages_id = pd.languages_id) WHERE products.products_id = ?";
        $stmt = $this->connect()->prepare($sql);
        $stmt->execute([$productId]);
        $result = $stmt->fetchAll();

        //Da vi kun skal bruge det ene produkt, da de er ens i hver row vi får tilbage, er der sat et [0].
        $product = new Product();
        $product->productId = $result[0]['products_id'];
        $product->productReference = $result[0]['products_reference'];
        $product->productPrice = $result[0]['products_price'];

        //Her laves en foreach som opretter samtlige produkt_descriptions som produktet har.
        foreach($result as $pd){
            $productDesc = new ProductDescription();
            $productDesc->productDetailId = $pd['products_description_id'];
            $productDesc->langName = $pd['languages_name'];
            $productDesc->productName = $pd['products_description_name'];
            $productDesc->productShortDesc = $pd['products_description_short_description'];
            $productDesc->productLongDesc = $pd['products_description_description'];

            array_push( $productList, $productDesc );
        }
        $product->detailList = $productList;

        return $product;
    }

    //Her slettes et et produkt ved hjælp af et ID, der slettes også alle i products_description hvis det har det givne product_id i sig.
    public function deleteProduct($productId){
        $sql = "DELETE FROM products_description WHERE products_id = ?;
        DELETE FROM products WHERE products_id= ?";
        
        $stmt = $this->connect()->prepare($sql);
        $stmt->execute([$productId, $productId]);
    }
  
    //Her oprettes et produkt
    public function createProduct($p, $pd){
        $con = $this->connect();
        $sql = "INSERT INTO products(products_reference, products_price) VALUES(?, ?)";
        $stmt = $con->prepare($sql);
        $stmt->execute([$p->productReference, (float)$p->productPrice]);
        
        //Her henter vi det sidste id som blev sat ind i databasen, da vi skal bruge det til at oprette product description
        $id = $con->lastInsertId();
        $sql2 ="INSERT INTO products_description(products_id, languages_id, products_description_name, 
        products_description_short_description, products_description_description) VALUES(?, ?, ?, ?, ?)";
        $stmt2 = $con->prepare($sql2);
        $stmt2->execute([(int)$id, 1, $pd->productName, $pd->productShortDesc, $pd->productLongDesc]);
    }

    //Her opdateres vores product, med alle de product_descriptions som den har på sig.
    public function updateProduct($product){
        $con = $this->connect();
        $sql = "UPDATE products set products_reference = ?, products_price = ? WHERE products_id = ?";
        $stmt = $con->prepare($sql);
        $stmt->execute([$product->productReference, (float)$product->productPrice, (int)$product->productId]);
        
        foreach($product->detailList as $item){
            $sql2 = "UPDATE products_description set products_description_name = ?, products_description_short_description = ?,
             products_description_description = ? WHERE products_description_id = ?";
            $stmt2 = $con->prepare($sql2);
            $stmt2->execute([$item->productName, $item->productShortDesc, $item->productLongDesc, (int)$item->productDetailId]);
        }
    }
}