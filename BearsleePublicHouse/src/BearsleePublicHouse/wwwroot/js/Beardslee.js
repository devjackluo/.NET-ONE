function isEmail( email )
{
  var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
  return regex.test( email );
}

$( document ).ready( function ()
{

  $( ".facebook-icon" ).mouseover( function ()
  {
      $(this).attr("src", "../images/Facebook_Mouseover.png");
  } ).mouseout( function ()
  {
      $(this).attr("src", "../images/Facebook.png");
  } );

  $( ".pinterest-icon" ).mouseover( function ()
  {
      $(this).attr("src", "../images/Pinterest_Mouseover.png");
  } ).mouseout( function ()
  {
      $(this).attr("src", "../images/Pinterest.png");
  } );

  $( ".beer-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/Beer_menu_Mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/Beer_menu.png" );
  } );

  $( ".drink-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/Drink_menu_Mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/Drink_menu.png" );
  } );

  $( ".happy-hour-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/HappyHour_menu_Mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/HappyHour_menu.png" );
  } );

  $( ".food-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/Food_menu_Mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/Food_menu.png" );
  } );

  $( ".gluten-free-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/GlutenFree_Menu_Mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/GlutenFree_Menu.png" );
  } );

  $( ".dinner-special-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/DinnerSpecial_menu_mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/DinnerSpecial_menu.png" );
  } );

  $( ".lunch-special-menu" ).mouseover( function ()
  {
    $( this ).attr( "src", "images/what-we-make/LunchSpecial_menu_mouseover.png" );
  } ).mouseout( function ()
  {
    $( this ).attr( "src", "images/what-we-make/LunchSpecial_menu.png" );
  });





} );