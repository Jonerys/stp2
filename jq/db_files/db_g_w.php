<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	
	$mode = null;
    $selID = null;
	$selNameG = null;
	$selNameW = null;
	
	
	if (isset($_POST['mode'])) $mode = $_POST['mode'];
    if (isset($_POST['selID'])) $selID = $_POST['selID'];
	if (isset($_POST['selNameG'])) $selNameG = $_POST['selNameG'];
	if (isset($_POST['selNameW'])) $selNameW = $_POST['selNameW'];
	
	if ($mode == "1") {
        $dataSource = mysqli_query($db, "SELECT goods_main.id idg, warehouses.id idw FROM goods_main, warehouses WHERE goods_main.name = '$selNameG' AND warehouses.name = '$selNameW'") or die("Ошибка " . mysqli_error($db));
        $result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
        $gID = $result[0]["idg"];
        $wID = $result[0]["idw"];
		$query ="INSERT INTO goodswh(id, id_gd, id_wh) VALUES(NULL, $gID, $wID)";
		$result = mysqli_query($db, $query) or die(); 
	}
	if($mode == "2"){
        $dataSource = mysqli_query($db, "SELECT goods_main.id idg, warehouses.id idw FROM goods_main, warehouses WHERE goods_main.name = '$selNameG' AND warehouses.name = '$selNameW'") or die("Ошибка " . mysqli_error($db));
        $result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
        $gID = $result[0]["idg"];
        $wID = $result[0]["idw"];
		$query ="UPDATE goodswh SET id_gd='$gID', id_wh='$wID' where id='$selID'";
		$result = mysqli_query($db, $query) or die(); 
	}
	if ($mode == "3"){
		$query ="DELETE FROM goodswh WHERE id = '$selID'";
		$result = mysqli_query($db, $query) or die();
	}
	$dataSource = mysqli_query($db, "SELECT goodswh.id, goods_main.name gn, warehouses.name wn FROM goodswh, goods_main, warehouses WHERE goodswh.id_gd = goods_main.id AND goodswh.id_wh = warehouses.id ORDER BY id ASC")
        or die("Ошибка " . mysqli_error($db));
	$result = mysqli_fetch_all($dataSource, MYSQLI_ASSOC);
	echo json_encode($result);
    mysqli_close($db);
?>