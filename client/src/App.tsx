import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import TicketList from "./components/ticket/TicketList";

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <TicketList />
    </QueryClientProvider>
  );
}

export default App;
