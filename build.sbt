name := "end_user_gui-draft"

version := "1.0"

lazy val `end_user_gui-draft` = (project in file(".")).enablePlugins(PlayJava)

scalaVersion := "2.11.1"

libraryDependencies ++= Seq( javaJdbc , javaEbean , cache , javaWs )

libraryDependencies += "com.google.inject" % "guice" % "4.0"

libraryDependencies += "org.codehaus.jackson" % "jackson-core-asl" % "1.9.13"

unmanagedResourceDirectories in Test <+=  baseDirectory ( _ /"target/web/public/test" )  