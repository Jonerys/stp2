<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	
	$mode = null;
	$name = null;
	$selID = null;
	
	if (isset($_POST['mode'])) $mode = $_POST['mode'];
	if (isset($_POST['name'])) $name = $_POST['name'];
	if (isset($_POST['selID'])) $selID = $_POST['selID'];
	
	if ($mode == "1") {
		$query ="INSERT INTO warehouses VALUES(NULL, '$name')";
		$result = mysqli_query($db, $query) or die(); 
	}
	if($mode == "2"){
		$query ="UPDATE warehouses SET name='$name' where id='$selID'";
		$result = mysqli_query($db, $query) or die(); 
	}
	if ($mode == "3"){
		$query ="DELETE FROM warehouses WHERE id = '$selID'";
		$result = mysqli_query($db, $query) or die();
	}
	$dataSource = mysqli_query($db, "SELECT * FROM warehouses ORDER BY id ASC") or die("Ошибка " . mysqli_error($db));
	$result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
	echo json_encode($result);
    mysqli_close($db);
?>