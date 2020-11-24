<?php
include_once "Dbh.php";
include_once "productsClasses.php";

class LanguagesDbh extends Dbh{
    
    //Her hentes alle de forskellige sprog som er i databasen, og oprettes om objekter og lagt i et array.
    public function getLanguages(){
        $languages = array();
        $sql = "SELECT * FROM languages";
        $stmt = $this->connect()->query($sql);
        $result = $stmt->fetchAll();
        foreach($result as $row){
            $language = new Languages();
            $language->languageId = $row['languages_id'];
            $language->languageName = $row['languages_name'];
            array_push($languages, $language);
        }
        return $languages;
    }

}