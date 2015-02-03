<script type="text/javascript">
         $(function() {
            $('#mybutton').click(function(){
               $(".button_contrast").switchClass("button_contrast","button_crazy",'fast');
               $(".button_crazy").switchClass("button_crazy","button_contrast",'fast');
               return false;
            });
         });
</script>
