import { Grid, GridItem, Center, Link } from "@chakra-ui/react";
import ChooseBoxComponent from "../Components/ChooseBoxComponent";
import "./../App.css";

const HomePage = () => (
  <Center h="100vh" className="backgroundDiv">
    <Grid
      width={"60%"}
      height={"60%"}
      templateRows="repeat(3, 30fr)"
      templateColumns="repeat(3, 30fr)"
      gap={4}
    >
      <GridItem rowSpan={2} colSpan={2}>
        <Link href="/page1">
          <ChooseBoxComponent name="Dodaj Operacje" background="black" />
        </Link>
      </GridItem>
      <GridItem rowSpan={2} colSpan={1}>
        <Link href="/page2">
          <ChooseBoxComponent name="Stwórz Pole" background="green" />
        </Link>
      </GridItem>
      <GridItem rowSpan={1} colSpan={2}>
        <Link href="/page3">
          <ChooseBoxComponent
            name="Stwórz konto dla pracownika"
            background="green"
          />
        </Link>
      </GridItem>
      <GridItem rowSpan={1} colSpan={1}>
        <Link href="/page4">
          <ChooseBoxComponent name="Statystyki" background="black" />
        </Link>
      </GridItem>
    </Grid>
  </Center>
);

export default HomePage;
