<html>
<head>
</head>
<body>
<?PHP
	
	header('Access-Control-Allow-Origin: *');
	
	include_once 'client/senha.php';
	include_once 'client/perfil.php';

	$perfilemissor = 1;
	$serv_codigo = 1;
	$preferencial = 'F';
	
	$senha = new senha();
	$id = $senha->incluiSenha($perfilemissor, $serv_codigo, $preferencial);
	
	$perfil = new perfil();
	$ret = $perfil->carregaCupomLayout($id, (!isset($perfilemissor) ? 0 : $perfilemissor));
	echo $ret;
	//echo json_encode($ret, JSON_HEX_QUOT);
	
?>

</body>
</html>