package asyncawaitdemo

import io.gatling.core.Predef._ 
import io.gatling.http.Predef._
import scala.concurrent.duration._

 
object Async {

  val search = exec(http("Async") // let's give proper names, as they are displayed in the reports
    .get("/homepage/indexAsync")
    .check(status.is(200))
    )
}

class AsyncSimulation extends Simulation { 

  val httpConf = http
      .baseURL("http://localhost:5004")
      .acceptHeader("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8") 
      .acceptLanguageHeader("en-US,en;q=0.5")
      .acceptEncodingHeader("gzip, deflate")
      .userAgentHeader("Mozilla/5.0 (Windows NT 5.1; rv:31.0) Gecko/20100101 Firefox/31.0")

  val users = scenario("Async").exec(Async.search)

  setUp(
    users.inject(rampUsers(1000) over (60 seconds))
  ).protocols(httpConf)

}