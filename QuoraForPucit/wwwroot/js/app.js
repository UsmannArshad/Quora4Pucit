var collection = document.getElementsByClassName("like-btn");
var collection1 = document.getElementsByClassName("dislike-btn");
for (let i = 0; i < collection.length; i++) {
    collection[i].onclick = function () {
        console.log("gg");
        if (collection[i].style.backgroundColor !=(0,0,255))
    {
            collection[i].style.backgroundColor = "rgb(0,0,255)";
            collection[i].style.color="rgb(255,255,255)"
            collection1[i].disabled = true;
    }
    else
    {
            collection[i].style.backgroundColor = "rgb(0,0,0)";
            collection[i].style.color = "rgb(0,0,255)"
            collection1[i].disabled = false;
    }  
  }
}
for (let i = 0; i < collection1.length; i++) {
  collection1[i].onclick=function(){
      if (collection1[i].style.backgroundColor !="rgb(139,0,0)")
    {
          collection1[i].style.backgroundColor = "rgb(139,0,0)";
          collection1[i].style.color = "rgb(255,255,255)"
          collection[i].disabled = true;
    }
    else
    {
          collection1[i].style.backgroundColor = "rgb(255,255,255)";
          collection1[i].style.color = "rgb(139,0,0)"
          collection[i].disabled = false;
    }  
  }
}