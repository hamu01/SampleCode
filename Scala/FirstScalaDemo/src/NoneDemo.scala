

object NoneDemo extends App {
  def getAStringMaybe(num: Int): Option[String] = {
       if ( num >= 0 ) Some("A positive number!")
       else None // A number less than 0?  Impossible!
  }
  
  def printResult(num: Int) = {
        getAStringMaybe(num) match {
          case Some(str) => println(str)
          case None => println("No string!")
        }
  }
  
  printResult(100)
}