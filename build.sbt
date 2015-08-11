name := "end_user_gui-draft"

version := "1.0"

lazy val `end_user_gui-draft` = (project in file(".")).enablePlugins(PlayJava)

scalaVersion := "2.11.1"

libraryDependencies ++= Seq( javaJdbc , javaEbean , cache , javaWs )

libraryDependencies += "com.google.inject" % "guice" % "4.0"

libraryDependencies += "org.codehaus.jackson" % "jackson-core-asl" % "1.9.13"

libraryDependencies += "de.sven-jacobs" % "loremipsum" % "1.0"

libraryDependencies += "com.google.code.gson" % "gson" % "2.3.1"

unmanagedResourceDirectories in Test <+=  baseDirectory ( _ /"target/web/public/test" )  