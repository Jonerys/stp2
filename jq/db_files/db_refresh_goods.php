<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	$data_source = mysqli_query($db, "SELECT * FROM goods_main ORDER BY id ASC") or die("Ошибка " . mysqli_error($db));
	$result = mysqli_fetch_all($data_source, MYSQLI_ASSOC);
	echo json_encode($result);
    mysqli_close($db);
?>