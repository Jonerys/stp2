<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	
	$mode = null;
	$name = null;
	$sel_id = null;
	
	if (isset($_GET['mode'])) $mode = $_GET['mode'];
	if (isset($_GET['name'])) $name = $_GET['name'];
	if (isset($_GET['sel_id'])) $sel_id = $_GET['sel_id'];
	
	if ($mode == "1") {
		$query ="INSERT INTO goods_main VALUES(NULL, '$name')";
		$result = mysqli_query($db, $query) or die(); 
	}
	if($mode == "2"){
		$query ="UPDATE goods_main SET name='$name' where id='$sel_id'";
		$result = mysqli_query($db, $query) or die(); 
	}
	if ($mode == "3"){
		$query ="DELETE FROM goods_main WHERE id = '$sel_id'";
		$result = mysqli_query($db, $query) or die();
	}
	$data_source = mysqli_query($db, "SELECT * FROM goods_main") or die("Ошибка " . mysqli_error($db));
	$result = mysqli_fetch_all($data_source, MYSQLI_ASSOC);
	echo json_encode($result);
	
	mysqli_close($db);
?>