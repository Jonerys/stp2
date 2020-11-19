<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	$dataSource = mysqli_query($db, "SELECT * FROM warehouses ORDER BY id ASC") or die("Ошибка " . mysqli_error($db));
	$result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
	echo json_encode($result);
    mysqli_close($db);
?>