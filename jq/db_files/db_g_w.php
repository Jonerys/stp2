<?php
	$db = mysqli_connect('localhost', 'root', '', 'goods') or die();
    mysqli_set_charset($db, 'utf8');
	
	$mode = null;
    $sel_id = null;
	$sel_ng = null;
	$sel_nw = null;
	
	
	if (isset($_POST['mode'])) $mode = $_POST['mode'];
    if (isset($_POST['sel_id'])) $sel_id = $_POST['sel_id'];
	if (isset($_POST['sel_ng'])) $sel_ng = $_POST['sel_ng'];
	if (isset($_POST['sel_nw'])) $sel_nw = $_POST['sel_nw'];
	
	if ($mode == "1") {
        $data_source = mysqli_query($db, "SELECT goods_main.id idg, warehouses.id idw FROM goods_main, warehouses WHERE goods_main.name = '$sel_ng' AND warehouses.name = '$sel_nw'") or die("Ошибка " . mysqli_error($db));
        $result = mysqli_fetch_all($data_source, MYSQLI_ASSOC);
        $g_id = $result[0]["idg"];
        $w_id = $result[0]["idw"];
		$query ="INSERT INTO goodswh(id, id_gd, id_wh) VALUES(NULL, $g_id, $w_id)";
		$result = mysqli_query($db, $query) or die(); 
	}
	if($mode == "2"){
        $data_source = mysqli_query($db, "SELECT goods_main.id idg, warehouses.id idw FROM goods_main, warehouses WHERE goods_main.name = '$sel_ng' AND warehouses.name = '$sel_nw'") or die("Ошибка " . mysqli_error($db));
        $result = mysqli_fetch_all($data_source, MYSQLI_ASSOC);
        $g_id = $result[0]["idg"];
        $w_id = $result[0]["idw"];
		$query ="UPDATE goodswh SET id_gd='$g_id', id_wh='$w_id' where id='$sel_id'";
		$result = mysqli_query($db, $query) or die(); 
	}
	if ($mode == "3"){
		$query ="DELETE FROM goodswh WHERE id = '$sel_id'";
		$result = mysqli_query($db, $query) or die();
	}
	$data_source = mysqli_query($db, "SELECT goodswh.id, goods_main.name gn, warehouses.name wn FROM goodswh, goods_main, warehouses WHERE goodswh.id_gd = goods_main.id AND goodswh.id_wh = warehouses.id ORDER BY id ASC")
        or die("Ошибка " . mysqli_error($db));
	$result = mysqli_fetch_all($data_source, MYSQLI_ASSOC);
	echo json_encode($result);
    mysqli_close($db);
?>