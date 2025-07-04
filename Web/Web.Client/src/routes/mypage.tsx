import { createFileRoute, Outlet } from '@tanstack/react-router'
import { getFromMyEndpointAsync } from '../api/myendpoint/get.myendpoint'
import { useSuspenseQuery } from '@tanstack/react-query'
import { myEndpointOptions } from '../api/myendpoint/options.myendpoint'

export const Route = createFileRoute('/mypage')({
  loader: ({ context: { queryClient } }) => {
    queryClient.ensureQueryData(myEndpointOptions);
  },
  component: RouteComponent,
})

function RouteComponent() {
  const myendpointQuery = useSuspenseQuery(myEndpointOptions);
  const data = myendpointQuery.data;
  return (
    <>
      <div>Hello {data?.name}!</div>
      <div>You are {data?.age} years old!</div>
      <Outlet />
    </>
  )
}
