import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import TicketList from "./components/ticket/TicketList";

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <div className="container mt-4 mb-5">
        <div className="d-flex justify-content-center">
          <TicketList />
        </div>
      </div>
    </QueryClientProvider>
  );
}

export default App;
