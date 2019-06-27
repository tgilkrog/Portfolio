<!DOCTYPE html>
<html>
    <head>
        <title>PHP CRUD</title>
        <script src="https://code.jquery.com/jquery-2.1.3.min.js"></script>
        <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
        <link rel="stylesheet" href="stylesheet.css">
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    </head>
    <body>
    <?php require_once 'process.php' ?>

    <?php if(isset($_SESSION['message'])): ?>

    <div class="alert alert-<?=$_SESSION['msg_type']?>">

            <?php 
                echo $_SESSION['message'];
                unset($_SESSION['message']);
            ?>
    </div>

    <?php endif ?>

    <div class="container">
    <?php
        $mysqli = new mysqli('localhost', 'root', '', 'crud') or die(mysqli_error($mysqli));
        $result = $mysqli->query('SELECT * FROM data') or die($mysqli->error);
        //pre_r($result);
    ?>

    <div class="row justify-content-center">
        <form action="process.php" method="POST">
        <?php if($update == true): ?>
            <h1>Update Person</h1>
            <?php else: ?>
                <h1>Create new Person</h1>
            <?php endif; ?>
        <input type="hidden" name="id" value="<?php echo $id; ?>">
            <div class="form-group">
                <label>Name</label>
                <input type="text" name="name" class="form-control" value="<?php echo $name; ?>" placeholder="Enter your name">
            </div>
            <div class="form-group">
                <label>Location</label>
                <input type="text" name="location" class="form-control" value="<?php echo $location; ?>" placeholder="Enter your location">
            </div>
            <div class="form-group">
            <?php if($update == true): ?>
            <button type="submit" name="update" class="btn btn-save">Update</button>
            <button type="submit" name="cancel" class="btn btn-delete">Cancel</button>
            <?php else: ?>
                <button type="submit" name="save" class="btn btn-save">Create New</button>
            <?php endif; ?>
            </div>
        </form>
    </div>

    <div class="row justify-content-center content">
        <table class="table">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Location</th>
                    <th colspan="2"></th>
                </tr>
            </thead>
        
    <?php while ($row = $result->fetch_assoc()): ?>
            <tr>
                <td><?php echo $row['name'] ?></td>
                <td><?php echo $row['location'] ?></td>
                <td>
                    <a href="index.php?edit=<?php echo $row['id']; ?>"
                        class="btn btn-save">Edit</a>
                    <a href="process.php?delete=<?php echo $row['id']; ?>"
                        class="btn btn-delete">Delete</a>
                </td>
            </tr>
    <?php endwhile; ?>
        </table>
    </div>

    </div>
    </body>
</html>