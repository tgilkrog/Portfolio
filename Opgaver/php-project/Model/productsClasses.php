<?php

//Her er alle de klasser der bliver brugt i programmet, satte dem bare i en enkelt fil, da det var nemmere da der kun er 3, ellers burde man jo lave en fil til hver.
class Product{
    public $productId;
    public $productReference;
    public $productPrice;
    public $productName;
    public $detailList;
}

class ProductDescription{
    public $productDetailId;
    public $langName;
    public $productName;
    public $productShortDesc;
    public $productLongDesc;
}

class Languages{
    public $languageId;
    public $languageName;
}